import React, {ChangeEvent, FormEvent, useState} from 'react';
import './Login.css'

function Login(props: LoginPropType) {
    const [loginInfo, setLoginInfo] = useState<LoginInfo>({
        username:'Jhon',
        password:'Pass123$',
        rememberMe:false
    })
    const onSelectChange = (event: ChangeEvent<HTMLInputElement>) => {
        setLoginInfo({
            ...loginInfo, [event.target.name]: event.target.checked
        });
    }
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
            <form onSubmit={onSubmit} className={`login-container`}>
                <div className={`login-field`}>
                    <label>Kullanıcı Adı</label>
                    <input name={`username`} type={`text`} value={loginInfo.username} onChange={onChange}/>
                </div>
                <div className={`login-field`}>
                    <label>Şifre</label>
                    <input name={`password`} type={`password`} value={loginInfo.password} onChange={onChange}/>
                </div>
                <div className={`login-field-checkbox`}>
                    <label htmlFor={`rememberMe`}>Beni Hatırla</label>
                    <input id={`rememberMe`} name={`rememberMe`} type={`checkbox`} checked={loginInfo.rememberMe} onChange={onSelectChange}/>
                </div>
                <div className={`login-field`}>
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
    password:string,
    rememberMe:boolean,
}
