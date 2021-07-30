import React from 'react';
import Login, {LoginInfo} from "../../components/login/Login";
import {useAuthService} from "../../hooks/auth-service";
import {useAppDispatch} from "../../app/hooks";
import {setAuthenticated, setUserInfo} from "../../features/session-info/userInfoSlice";
import {useHistory} from "react-router-dom";

function LoginPage(props:LoginPagePropType) {
    const authenticationService = useAuthService();
    const dispatch = useAppDispatch();
    const history = useHistory();
    if (authenticationService.isAuthenticated()){
        history.push(`/`);
    }
    const handleLogin = async (loginInfo:LoginInfo) => {
        const result = await authenticationService.login(loginInfo.username, loginInfo.password);
        if (result.isSuccessful){
            dispatch(setUserInfo({
                token : result.token,
                username: result.username
            }));
            dispatch(setAuthenticated(true));
            console.log("push")
            history.push(`/`);
        }
    }
    return (
        <div>
            <Login onLoginSubmit={handleLogin}/>
        </div>
    );
}

export default LoginPage;

export interface LoginPagePropType{

}
