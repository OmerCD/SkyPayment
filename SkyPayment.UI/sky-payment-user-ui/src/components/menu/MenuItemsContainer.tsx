import React, {useEffect, useState} from 'react';
import {MenuItemResponse, MenuResponseModel, ProductContent} from "./interfaces";
import MenuItem from "./MenuItem";
import './MenuItemsContainer.scss'
import BottomBar from "./BottomBar";
import ItemDetail from "../item/ItemDetail";
import {useMenuService} from "../../hooks/menu-service";
import {useAppSelector} from "../../app/hooks";
import {selectRestaurantId} from "../../features/session-info/sessionInfoSlice";
import {log} from "util";

export interface MenuItemsContainerPropType {
    menuInfo: MenuResponseModel
}

interface MenuItem {
    id: string;
    name: string;
    price: number;
    ingredients: string;
    productContents: ProductContent[];
    imageUrl: string;
}

function MenuItemsContainer(menuInfo: MenuItemsContainerPropType) {
    let {items} = menuInfo.menuInfo;
    const menuService = useMenuService();
    const restaurantId = useAppSelector(selectRestaurantId);
    const [headerClass, setHeaderClass] = useState<string>('menu-header');
    const [showItemDetail, setShowItemDetail] = useState<boolean>(false);
    const [itemSelection, setItemSelection] = useState<MenuItem>();
    const [scroll, setScroll] = useState<number>(0);
    const onItemSelect = async (id: string) => {
        if (restaurantId) {
            const response = await menuService.getMenuItem(restaurantId, menuInfo.menuInfo.menuId, id);
            setShowItemDetail(true);
            setItemSelection(response);
        }
    };
    const mappedItems = items.map(menuItem => {
        return (
            <MenuItem key={menuItem.name} menuItem={menuItem} onSelect={(id:string) => {
                setScroll(window.scrollY);
                return onItemSelect(id);
            }}/>
        )
    });
    useEffect(() => {
        window.addEventListener('scroll', onScroll)

        function onScroll(ev: Event) {
            if (window.scrollY > 70 && headerClass === 'menu-header') {
                setHeaderClass('menu-header menu-header-sliding')
            } else if (window.scrollY < 70 && headerClass === 'menu-header menu-header-sliding') {
                setHeaderClass('menu-header')
            }
        }
        return () => window.removeEventListener('scroll', onScroll);
    }, []);
    useEffect(()=>{
        if(!showItemDetail){
            window.scroll({
                top:scroll
            });
        }
    }, [showItemDetail])
    if (showItemDetail && itemSelection) {
        return (
            <ItemDetail {...itemSelection} close={() => {setShowItemDetail(false);}}/>
        )
    }

    return (
        <div style={{height: '100vh'}}>
            <div className='menu-items-container'>
                <h1 className={headerClass}>{menuInfo.menuInfo.name}</h1>
                {mappedItems}
            </div>
            <BottomBar/>
        </div>
    );
}

export default MenuItemsContainer;
