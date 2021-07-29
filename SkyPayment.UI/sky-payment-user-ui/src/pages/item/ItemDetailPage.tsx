import React from 'react';
import './ItemDetailPage.css';
import ItemDetail from "../../components/item/ItemDetail";
import {ProductContent} from "../../components/menu/interfaces";

function ItemDetailPage(props: ItemDetailPagePropType) {
    return (
        <div>
            {/*<ItemDetail {...props} close={()=>{}}/>*/}
        </div>
    );
}

export default ItemDetailPage;

export interface ItemDetailPagePropType {
    id: string;
    name: string;
    price: number;
    ingredients: string;
    productContent: ProductContent;
    imageUrl?: string;
}
