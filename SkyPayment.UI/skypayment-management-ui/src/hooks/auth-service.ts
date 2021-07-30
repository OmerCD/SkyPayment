import {AxiosInstance} from "axios";
import qs from 'qs';
import {useAxiosApi} from "../contexts/api-axios-context";
import {useAppDispatch, useAppSelector} from "../app/hooks";
import {AnyAction, ThunkDispatch} from "@reduxjs/toolkit";
import {AppDispatch, RootState} from "../app/store";
import {IUserInformation, selectUserInfo, setAuthenticated, setUserInfo} from "../features/session-info/userInfoSlice";
import {TypedUseSelectorHook} from "react-redux";

export class AuthenticationService {
    private readonly _identityApi: AxiosInstance;
    private readonly _baseApi: AxiosInstance;
    private readonly _dispatch: ThunkDispatch<AppDispatch, null, AnyAction>;
    private readonly _selector: TypedUseSelectorHook<RootState>;

    constructor(identityApi: AxiosInstance, baseApi: AxiosInstance, dispatch: ThunkDispatch<AppDispatch, null, AnyAction>, appSelector: TypedUseSelectorHook<RootState>) {
        this._identityApi = identityApi
        this._baseApi = baseApi;
        this._dispatch = dispatch;
        this._selector = appSelector
    }

    async login(username: string, password: string): Promise<LoginResponse> {
        const requestData = {
            client_id: "manager",
            client_secret: "d96453c3-2e49-4b88-b925-5899e06432b5",
            grant_type: 'password',
            username: username,
            password: password,
            scope: 'manager'
        };
        if (!this._identityApi) {
            return {isSuccessful: false, username: '', token: ''};
        }

        const response = await this._identityApi.post('/connect/token', qs.stringify(requestData));
        this.setToken(response.data.access_token);
        return {
            isSuccessful: response.status === 200,
            username: username,
            token: response.data.access_token
        };
    }

    setToken(token: string) {
        localStorage.setItem("token", token);
        this._baseApi.defaults.headers["Authorization"] = `Bearer ${token}`;
    }
    isAuthenticated():boolean{
        const token = localStorage.getItem("token");
        return token !== undefined && token !== null;
    }
    getUserInfo():IUserInformation{
        return this._selector(selectUserInfo).userInfo;
    }
    logout():void{
        localStorage.removeItem("token");
        this._dispatch(setAuthenticated(false))
    }
}

export function useAuthService(): AuthenticationService {
    const apiServices = useAxiosApi();
    const dispatch = useAppDispatch();
    const service = new AuthenticationService(
        apiServices.identityApi,
        apiServices.baseApi,
        dispatch,
        useAppSelector)
    return service;
}

export interface LoginResponse {
    isSuccessful: boolean;
    username: string;
    token: string;
}
