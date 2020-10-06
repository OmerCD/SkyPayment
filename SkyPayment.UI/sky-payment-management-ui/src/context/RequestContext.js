import {createContext, useContext} from "react";
import axios from '../axios-options';
import appsettings from '../appsettings.json';
import {useAuth} from "./AuthContext";

export const RequestContext = createContext(axios.create({
    baseURL:appsettings.apiAddress,
    headers: {
        "Authorization": 'Bearer ' + JSON.parse(localStorage.getItem('token')?.token ?? "{}")
    }
}));

export function useRequest(){
    const axiosInstance = useContext(RequestContext);
    const authContext = useAuth();
    axiosInstance.interceptors.response.use(response => {
        return response;
    }, error => {
        console.log(error);
        if (error.response?.status === 401){
            localStorage.removeItem('token');
            authContext.setToken(null);
        }
        return error.response;
    });

    return axiosInstance;
}
