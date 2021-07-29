import React from 'react';
import {MenuItemResponse} from "./interfaces";
import './MenuItem.css';

interface MenuItemPropType {
    menuItem: MenuItemResponse;
    onSelect: (id: string) => void;
}

function MenuItem(props: MenuItemPropType) {
    const {menuItem} = props;
    return (
        <div className='menu-item-card' onClick={() => props.onSelect(props.menuItem.id)}>
            <div className='menu-item-card-image'>
                <img src={"http://lorempixel.com/110/110/food/"}/>
            </div>
            <div className='menu-item-card-info'>
                <div className='menu-item-card-info_description'>
                    <div className='menu-item-card-info_description_name'>{menuItem.name}</div>
                    <div className='menu-item-card-info_description_ingredients'> {menuItem.ingredients}</div>
                </div>
                <div className='menu-item-card-info_price'>
                    <label>{menuItem.price}₺</label>
                </div>
            </div>
        </div>
    );
}

export default MenuItem;
