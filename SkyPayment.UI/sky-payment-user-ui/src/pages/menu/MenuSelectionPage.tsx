import React, {useEffect, useState} from "react";
import MenuList from "../../components/menu/MenuList";
import {IMenuListItem} from "../../components/menu/interfaces";
import {RouteComponentProps} from "react-router-dom";
import {useAppDispatch} from "../../app/hooks";
import {setRestaurantId, setTableId} from "../../features/session-info/sessionInfoSlice";
import './MenuSelectionPage.css'
import {useMenuService} from "../../hooks/menu-service";
import SkyLoader from "../../components/loader/SkyLoader";

export type MenuSelectionPagePropType =
    RouteComponentProps<{ restaurantId: string, tableId: string }>
    & { onMenuSelected: (menuId: string) => void };

export default function MenuSelectionPage({match: {params}, onMenuSelected}: MenuSelectionPagePropType) {
    const dispatch = useAppDispatch();
    const menuService = useMenuService();
    const [menus, setMenus] = useState<IMenuListItem[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    dispatch(setRestaurantId(params.restaurantId));
    dispatch(setTableId(params.tableId));
    const handleMenuSelect = (id: string) => {
        if (id !== undefined && id !== null) {
            onMenuSelected(id);
        }
    }
    const testMenus: IMenuListItem[] = [
        {id: "123", name: "Sıcaklar", onSelected: handleMenuSelect},
        {id: "124", name: "Soğuklar", onSelected: handleMenuSelect},
        {id: "125", name: "İçkiler", onSelected: handleMenuSelect},
        {id: "126", name: "Kahvaltılar", onSelected: handleMenuSelect},
    ];
    useEffect(() => {
        menuService.getMenuList(params.restaurantId).then(response => {
            const results:IMenuListItem[] = response as IMenuListItem[];
            setMenus(results.map(x=> {
                x.onSelected = handleMenuSelect
                return x;
            }));
        }).catch(() => {
            setMenus(testMenus);
        }).finally(() => {
            setLoading(false);
        });
    }, []);

    if (menus.length === 1) {
        onMenuSelected(menus[0].id);
        return <></>
    }

    return (
        <div className={`menu-list-container-page ${loading ? 'menu-list-center' : ''}`}>
            {loading ? <SkyLoader/> : <MenuList menus={menus}/>}

        </div>
    )
}
