import axios, {AxiosInstance} from "axios";
import {Context, createContext, useContext} from "react";
import {useHistory} from "react-router-dom";

const defaultBaseAxios = axios.create({
    baseURL: process.env.REACT_APP_API_ADDRESS
})
const defaultIdentityAxios = axios.create({
    baseURL: process.env.REACT_APP_IDENTITY_ADDRESS
})

export interface ApiServices {
    baseApi: AxiosInstance,
    identityApi: AxiosInstance
}

const defaultServices = {
    baseApi: defaultBaseAxios, identityApi: defaultIdentityAxios
};
export const AxiosContext: Context<ApiServices> = createContext(defaultServices);

export const AxiosProvider = ({children}: any) => {
    const history = useHistory();
    defaultBaseAxios.interceptors.response.use(response => response.data,
        error => {
            if (error.response.status === '401') {
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
