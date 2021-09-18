import axios, {AxiosInstance} from "axios";
import {Context, createContext, useContext} from "react";
import {useHistory} from "react-router-dom";
import {useAuthService} from "../hooks/auth-service";

const defaultBaseAxios = axios.create({
    baseURL: process.env.REACT_APP_API_ADDRESS
})
const defaultIdentityAxios = axios.create({
    baseURL: process.env.REACT_APP_IDENTITY_ADDRESS
})

export interface ApiServices {
    baseApi: AxiosInstance,
    identityApi: AxiosInstance,
    setToken: (token:string)=>void,
}

const defaultServices = {
    baseApi: defaultBaseAxios, identityApi: defaultIdentityAxios, setToken:(token:string) =>{
        defaultBaseAxios.defaults.headers[`Authorization`] = `Bearer ${token}`;
    }
};
export const AxiosContext: Context<ApiServices> = createContext(defaultServices);

export const AxiosProvider = ({children}: any) => {
    const history = useHistory();
    const authService = useAuthService();
    const token = localStorage.getItem('token');
    if (token) {
        defaultBaseAxios.defaults.headers[`Authorization`] = `Bearer ${token}`;
    }
    defaultBaseAxios.interceptors.response.use(value => value,
        error => {
            console.log(error)
            if (error.response.status === 401) {
                localStorage.removeItem('token');
                authService.logout();
                history.push('/login');
            }
        })
    return (
        <AxiosContext.Provider value={defaultServices}>
            {children}
        </AxiosContext.Provider>
    )
}

export function useAxiosApi(): ApiServices {
    return useContext(AxiosContext);
}
