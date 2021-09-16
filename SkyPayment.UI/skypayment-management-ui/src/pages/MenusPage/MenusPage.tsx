import React, {useEffect, useState} from 'react';
import {useMenuService} from "../../hooks/menu-service";
import {MenuResponseModel} from "../../api-models/menu/MenuResponseModel";
import './MenusPage.css';
import SkyTable from "../../components/table/SkyTable";
import TablePagination from "../../components/table/TablePagination";
import Fab, {FabColorType} from "../../components/fab/Fab";

interface MenuTableItem extends MenuResponseModel {
    actions: any
}

function MenusPage(props: MenusPagePropType) {
    const menuService = useMenuService();
    const [menus, setMenus] = useState<MenuResponseModel[]>([]);
   
    useEffect(() => {
        const getAndSetMenus = async () => {
            const data = await menuService.getMenus();
            setMenus(data)
        }
        getAndSetMenus();
    }, []);
    return (
        <>
            <SkyTable headers={[{name:'İsim'}, {name:'Adet'}]} content={menus.map(menu => {
                return {
                    id:menu.id,
                    name: menu.name,
                    count: menu.items.length
                }
            })} hasActions={true}
                      onEditClick={(id)=> alert("Edit Modal :"+id)}
                      onDeleteClick={(id)=> alert("Delete Modal :"+id)}
            />
            <TablePagination maxPage={50} maxItemPerPage={10} currentPage={2} requestFunction={(page)=>{}}/>
            <Fab onClick={()=>alert()} type={FabColorType.Success}/>
        </>
    )
}

export default MenusPage;

export interface MenusPagePropType {

}
