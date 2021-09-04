import {AxiosInstance} from "axios";
import qs from 'qs';
import {ApiServices, useAxiosApi} from "../contexts/api-axios-context";
import {useAppDispatch, useAppSelector} from "../app/hooks";
import {AnyAction, ThunkDispatch} from "@reduxjs/toolkit";
import {AppDispatch, RootState} from "../app/store";
import {IUserInformation, selectUserInfo, setAuthenticated} from "../features/session-info/userInfoSlice";
import {TypedUseSelectorHook} from "react-redux";

export class AuthenticationService {
    private readonly _identityApi: AxiosInstance;
    private readonly _baseApi: AxiosInstance;
    private readonly _dispatch: ThunkDispatch<AppDispatch, null, AnyAction>;
    private readonly _selector: TypedUseSelectorHook<RootState>;
    private readonly _setApiToken: (token: string) => void;

    constructor(apiServices:ApiServices, dispatch: ThunkDispatch<AppDispatch, null, AnyAction>, appSelector: TypedUseSelectorHook<RootState>) {
        this._identityApi = apiServices.identityApi
        this._baseApi = apiServices.baseApi;
        this._setApiToken = apiServices.setToken;
        this._dispatch = dispatch;
        this._selector = appSelector
        const token = localStorage.getItem('token');
        if (token) {
            this._baseApi.defaults.headers[`Authorization`] = `Bearer ${token}`;
        }
    }

    async login(username: string, password: string): Promise<LoginResponse> {
        const requestData = {
            client_id: "user",
            client_secret: "10d570c5-64a6-4656-94da-cf6506e51106",
            grant_type: 'password',
            username: username,
            password: password,
            scope: 'user'
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
        this._setApiToken(token);
    }

    isAuthenticated(): boolean {
        const token = localStorage.getItem("token");
        return token !== undefined && token !== null;
    }

    getUserInfo(): IUserInformation {
        return this._selector(selectUserInfo).userInfo;
    }

    logout(): void {
        localStorage.removeItem("token");
        this._dispatch(setAuthenticated(false))
    }
}

export function useAuthService(): AuthenticationService {
    const apiServices = useAxiosApi();
    const dispatch = useAppDispatch();
    const service = new AuthenticationService(
        apiServices,
        dispatch,
        useAppSelector)
    return service;
}

export interface LoginResponse {
    isSuccessful: boolean;
    username: string;
    token: string;
}
