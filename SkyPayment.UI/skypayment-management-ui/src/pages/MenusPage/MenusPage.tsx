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
    const [pageSize, setPageSize] = useState<number>(20);
    const [menus, setMenus] = useState<MenuResponseModel[]>([]);
    const getAndSetMenus = async () => {
        const data = await menuService.getMenus();
        setMenus(data)
    }
    useEffect(() => {

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
            <TablePagination maxPage={menus.length / pageSize < 1 ? 1 : Math.ceil(menus.length / pageSize)} maxItemPerPage={pageSize} currentPage={1} requestFunction={(page)=>{}}/>
            <Fab onClick={()=>alert()} type={FabColorType.Success}/>
        </>
    )
}

export default MenusPage;

export interface MenusPagePropType {

}
