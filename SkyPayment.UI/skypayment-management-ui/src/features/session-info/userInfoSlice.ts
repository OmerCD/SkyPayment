import {createSlice, PayloadAction} from "@reduxjs/toolkit";
import {RootState} from "../../app/store";

export interface UserInfoState {
    userInfo:IUserInformation,
    isAuthenticated:boolean,
}

export interface IUserInformation{
    username?: string | null;
    token:string | null;
    fullName?:string | null;
}

const initialState: UserInfoState = {
    userInfo:{token:null, username:null, fullName:null,},
    isAuthenticated:false
};

const userInfoSlice = createSlice({
    name: "userInfo",
    initialState,
    reducers: {
        setUserInfo(state, action: PayloadAction<IUserInformation>){
            state.userInfo = action.payload;
        },
        setAuthenticated(state, action: PayloadAction<boolean>){
            state.isAuthenticated = action.payload;
        }
    }
});

const selectUserInfo = (state: RootState) => state.userInfo;
const selectAuthenticationState = (state: RootState) => {
    return state.userInfo.isAuthenticated;
};

export const { setUserInfo,setAuthenticated} = userInfoSlice.actions;
export {userInfoSlice, selectUserInfo, selectAuthenticationState};
export default userInfoSlice.reducer;

