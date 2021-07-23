import React from 'react';
import {IMenuListProps} from "./interfaces";
import MenuListItem from "./MenuListItem";
import './MenuList.css'

function MenuList(props: IMenuListProps) {
    const mappedList = props.menus.map(menuItem => {
        return (
            <MenuListItem {...menuItem} key={menuItem.id}/>
        )
    })
    return (
            <div className='menu-list-container'>
                {mappedList}
            </div>
    );
}

export default MenuList;
