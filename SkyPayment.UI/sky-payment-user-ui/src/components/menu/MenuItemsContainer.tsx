import React from 'react';
import {MenuResponseModel} from "./interfaces";
import MenuItem from "./MenuItem";
import './MenuItemsContainer.scss'

interface MenuItemsContainerPropType{
    menuInfo:MenuResponseModel
}

function MenuItemsContainer({menuInfo: {items}}: MenuItemsContainerPropType) {
    items = [...items, ...items, ...items];
    const mappedItems = items.map(menuItem => {
        return (
            <MenuItem key={menuItem.name} menuItem={menuItem}/>
        )
    });
    return (
        <div className='menu-items-container'>
            {mappedItems}
        </div>
    );
}

export default MenuItemsContainer;
