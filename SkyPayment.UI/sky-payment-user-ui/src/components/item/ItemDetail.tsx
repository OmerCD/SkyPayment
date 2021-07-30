import React from 'react';
import './ItemDetail.css';
import {ProductContent} from "../menu/interfaces";
import {faMinus, faPlus} from "@fortawesome/free-solid-svg-icons";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import ContentPill from "../content/ContentPill";
import {useAppDispatch, useAppSelector} from "../../app/hooks";
import {addItem, removeLastItemByMenuId, selectBasketItemCount} from "../../features/basket/basketSlice";

function ItemDetail(props: ItemDetailPropType) {
    const dispatch = useAppDispatch();
    const itemCount = useAppSelector((state) => selectBasketItemCount(state, props.id));
    const imageStyle = {backgroundImage: `url(${props.imageUrl})`}
    const contentPills = props.productContents.map(content => {
        return (
            <ContentPill key={content.type} type={content.type} text={content.displayName}/>
        )
    });
    const addToBasket = () => {
        console.log("add")
        dispatch(addItem({
            id: props.id,
            menuItemId: props.id,
            name: props.name,
            price: props.price
        }))
    }
    const removeFromBasket = () => {
        console.log("remove")
        dispatch(removeLastItemByMenuId(props.id));
    }
    return (
        <div className='item-detail-container'>
            <div style={imageStyle} className={'item-detail-image'}/>
            <div className='item-detail-contents'>
                {contentPills}
            </div>
            <div className='item-detail-description'>
                <div className='item-detail-description_header'>{props.name}</div>
                <div className='item-detail-description_ingredients'>{props.ingredients}</div>
            </div>
            <div className='item-detail-price'>
                <label>{props.price}₺</label>
            </div>
            <div className='item-detail-add-to-basket'>
                <div className={`item-detail-add-to-basket_symbols`}>
                    <div className='symbol' onClick={() => removeFromBasket()}>
                        <FontAwesomeIcon icon={faMinus}/>
                    </div>
                    <div className={`count`}>{itemCount}</div>
                    <div className='symbol' onClick={() => addToBasket()}>
                        <FontAwesomeIcon icon={faPlus}/>
                    </div>
                </div>
            </div>
            <div className={`item-detail-close`} onClick={props.close}>
                <FontAwesomeIcon icon={faPlus}/>
            </div>
        </div>
    );
}

export default ItemDetail;

export interface ItemDetailPropType {
    id: string;
    name: string;
    price: number;
    ingredients: string;
    productContents: ProductContent[];
    imageUrl?: string;
    close: () => void;
}
