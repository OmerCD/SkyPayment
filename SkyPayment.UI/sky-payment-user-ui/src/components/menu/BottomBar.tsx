import React from 'react';
import './BottomBar.css';
import {useAppSelector} from "../../app/hooks";
import {selectBasketAllItemCount} from "../../features/basket/basketSlice";
import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import {faUser, faShoppingCart} from "@fortawesome/free-solid-svg-icons";


interface BottomBarPropType {

}


function BottomBar(props: BottomBarPropType) {
    const basketItemCount = useAppSelector(selectBasketAllItemCount);
    return (
        <div className='bottom-bar-container'>
            <div className='bottom-bar-container_items'>
                <div className='bottom-bar-container_items_item profile'>
                    <FontAwesomeIcon icon={faUser} onClick={alert}/>
                </div>
                <div className='bottom-bar-container_items_item basket'>
                    <div>
                        <FontAwesomeIcon icon={faShoppingCart}/>
                        <label className='bottom-bar-container_items_item basket-count'>{basketItemCount}</label>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default BottomBar;
