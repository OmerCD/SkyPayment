import React, {ChangeEvent, FormEvent, useState} from 'react';
import './Login.css'

function Login(props: LoginPropType) {
    const [loginInfo, setLoginInfo] = useState<LoginInfo>({
        username:'Alice',
        password:'Pass123$'
    })
    const onChange = (event: ChangeEvent<HTMLInputElement>) =>{
        setLoginInfo({
            ...loginInfo, [event.target.name]: event.target.value
        });
    }
    const onSubmit = (event:FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        props.onLoginSubmit(loginInfo);
    }
    return (
        <div>
            <form onSubmit={onSubmit}>
                <div>
                    <label>Kullanıcı Adı</label>
                    <input name={`username`} type={`text`} value={loginInfo.username} onChange={onChange}/>
                </div>
                <div>
                    <label>Şifre</label>
                    <input name={`password`} type={`password`} value={loginInfo.password} onChange={onChange}/>
                </div>
                <div>
                    <button type={`submit`}>Giriş</button>
                </div>
            </form>
        </div>
    );
}

export default Login;

export interface LoginPropType {
    onLoginSubmit: (loginInfo:LoginInfo) => void;
}
export interface LoginInfo{
    username:string,
    password:string
}
