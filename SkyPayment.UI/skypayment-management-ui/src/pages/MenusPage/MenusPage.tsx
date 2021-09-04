import React, {useEffect, useMemo, useState} from 'react';
import {useMenuService} from "../../hooks/menu-service";
import {MenuResponseModel} from "../../api-models/menu/MenuResponseModel";
import './MenusPage.css';
import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import {faEdit, faWindowClose} from "@fortawesome/free-solid-svg-icons";

interface MenuTableItem extends MenuResponseModel {
    actions: any
}

function MenusPage(props: MenusPagePropType) {
    const menuService = useMenuService();
    const [menus, setMenus] = useState<MenuTableItem[]>([]);
    const getAndSetMenus = async () => {
        const data = await menuService.getMenus();
        setMenus(data.map(x => {
            return {
                ...x,
                actions: (<div>
                    <button className={"btn-edit"}>
                        <FontAwesomeIcon icon={faEdit}/>
                        <span>Düzenle</span>
                    </button>
                    <button className={`btn-delete`}>
                        <FontAwesomeIcon icon={faWindowClose}/>
                        <span>Sil</span>
                    </button>
                </div>)
            }
        }))
    }
    useEffect(() => {
        getAndSetMenus();
    }, []);
    const mapped = menus.map(item => {
        return (
            <tr>
                <td>{item.name}</td>
                <td>{item.items.length}</td>
                <td className={`menus-table_actions`}>{item.actions}</td>
            </tr>
        )
    })
    return (
        <table className={`menus-table`}>
            <thead>
            <tr>
                <th>İsim</th>
                <th>Adet</th>
                <th className={`menus-table_actions`}>Aksiyonlar</th>
            </tr>
            </thead>
            <tbody>
            {mapped}
            </tbody>
        </table>
    )
}

export default MenusPage;

export interface MenusPagePropType {

}
