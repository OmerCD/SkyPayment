import {createContext, useContext} from "react";

export const AuthContext = createContext({
    token: JSON.parse(localStorage.getItem('token'))?.token,
    setToken: (token) => {
    }
});

export function useAuth() {
    return useContext(AuthContext);
}
