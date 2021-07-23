import React from 'react';
import {IMenuListItem} from "./interfaces";
import './MenuListItem.css'

function MenuListItem(props: IMenuListItem) {
    return (
        <div className='menu-list-item' onClick={() => props.onSelected(props.id)}>
            <div className='menu-list-item_image'>
                <img src={"http://lorempixel.com/167/163/food/"} width='100%' height='100%'/>
            </div>
            <div className='menu-list-item_name'>{props.name}</div>
        </div>
    );
}

export default MenuListItem;
