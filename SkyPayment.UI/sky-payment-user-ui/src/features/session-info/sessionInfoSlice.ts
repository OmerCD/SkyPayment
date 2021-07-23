import {createSlice, PayloadAction} from "@reduxjs/toolkit";
import {RootState} from "../../app/store";

export interface SessionInfoState{
    restaurantId?: string;
    tableId?:string;
}

const initialState : SessionInfoState = {

}

export const sessionInfoSlice = createSlice({
    name:"session-info",
    initialState,
    reducers:{
        setRestaurantId(state, action: PayloadAction<string>){
            state.restaurantId = action.payload;
        },
        setTableId(state, action: PayloadAction<string>){
            state.tableId = action.payload;
        }
    }
});

export const {setRestaurantId, setTableId} = sessionInfoSlice.actions;

export const selectRestaurantId = (state:RootState) => state.sessionInfo.restaurantId;

export default sessionInfoSlice.reducer;
