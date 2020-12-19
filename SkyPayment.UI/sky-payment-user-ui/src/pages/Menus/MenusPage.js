import React from "react";
import MenuItem from "../../components/menu/MenuItem";
import MenuList from "../../components/menu/MenuList";
import './MenusPage.css';

const mockMenus = [
    {
        id:1,
        title: 'Test1',
        subTitle: 'SubTest1',
        description: 'Description 1'
    },
    {
        id:2,
        title: 'Test2',
        subTitle: 'SubTest2',
        description: 'Description 2'
    }
]

function MenusPage() {
    const params = new URLSearchParams(window.location.search);
    const managementId = params.get('managementUserId');
    const restaurantId = params.get('restaurantId');
    return (
        <div className='menus-main-container'>
            <MenuList
                menuItems={mockMenus}
                onMenuSelected={(id)=>alert(id)}
            />
        </div>
    )
}

export default MenusPage;
