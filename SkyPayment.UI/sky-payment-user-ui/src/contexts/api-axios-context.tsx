import axios, {AxiosInstance} from "axios";
import {Context, createContext, useContext} from "react";

const defaultAxios = axios.create({
    baseURL: process.env.REACT_APP_API_ADDRESS
})

export const AxiosContext:Context<AxiosInstance> = createContext(defaultAxios);

export const AxiosProvider = ({children}:any) => {
    return (
        <AxiosContext.Provider value={defaultAxios}>
            {children}
        </AxiosContext.Provider>
    )
}
export const useAxiosApi = () => {
    return useContext(AxiosContext);
}
