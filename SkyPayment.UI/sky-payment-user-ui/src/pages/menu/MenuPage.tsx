import React, {useEffect, useState} from 'react';
import {RouteComponentProps} from "react-router-dom";
import {useMenuService} from "../../hooks/menu-service";
import {MenuResponseModel} from "../../components/menu/interfaces";
import SkyLoader from "../../components/loader/SkyLoader";
import './MenuPage.css';
import MenuItemsContainer from "../../components/menu/MenuItemsContainer";

type MenuPagePropType = RouteComponentProps<{ restaurantId: string, menuId: string }> & {}

function MenuPage(props: MenuPagePropType) {
    const {params} = props.match;
    const menuService = useMenuService();
    const [menuContent, setMenuContent] = useState<MenuResponseModel>();
    const [loading, setLoading] = useState<boolean>(true);
    useEffect(() => {
        menuService.getMenuContent(params.restaurantId, params.menuId).then(response => {
            setMenuContent(response)
        }).finally(() => {
            setLoading(false)
        });
    }, [])
    return (
        <div className={`menu-items-page ${loading ? 'menu-items-center' : ''}`}>
            {loading ? <SkyLoader/> : (
                <>
                    <MenuItemsContainer menuInfo={menuContent as MenuResponseModel}/>
                </>
            )}
        </div>
    );
}

export default MenuPage;
