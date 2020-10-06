import {createContext, useContext} from "react";
import axios from '../axios-options';
import appsettings from '../appsettings.json';

export const RequestContext = createContext(axios.create({
    baseURL:appsettings.apiAddress,
    headers: {
        "Authorization": 'Bearer ' + JSON.parse(localStorage.getItem('token')?.token ?? "{}")
    }
}));

export function useRequest(){
    return useContext(RequestContext);
}
