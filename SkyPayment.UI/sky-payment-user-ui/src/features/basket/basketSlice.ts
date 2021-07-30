import {createSlice, PayloadAction} from "@reduxjs/toolkit";
import {RootState} from "../../app/store";
import {findLastIndex} from "../../extensions";

export interface BasketState {
    items: BasketItem[]
}

export interface BasketItem {
    name: string,
    id: string,
    menuItemId:string,
    price: number,
}

const initialState: BasketState = {
    items: []
}

export const basketSlice = createSlice({
    name: "basket",
    initialState,
    reducers: {
        addItem(state, action: PayloadAction<BasketItem>) {
            state.items.push(action.payload);
        },
        removeItemById(state, action: PayloadAction<string>) {
            if(state.items.length == 0) return;
            const index = state.items.findIndex(x => x.id === action.payload);
            state.items.splice(index, 1);
        },
        removeLastItemByMenuId(state, action:PayloadAction<string>){
            if(state.items.length == 0) return;
            const index = findLastIndex(state.items, x=> x.id === action.payload);
            state.items.splice(index, 1);
        }
    }
});

export const {addItem, removeItemById, removeLastItemByMenuId} = basketSlice.actions;

export const selectBasketItems = (state: RootState) => state.basket.items;
export const selectBasketAllItemCount = (state: RootState) => state.basket.items.length;
export const selectBasketItemCount = (state: RootState, id: string) => state.basket.items.filter(x=>x.menuItemId === id).length;

export default basketSlice.reducer;
