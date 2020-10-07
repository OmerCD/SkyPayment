import React, {useState} from "react";
import Login from "../../components/login/Login";
import AuthenticationService from "../../services/AuthenticationService";
import {useAuth} from "../../context/AuthContext";
import './Login.css';
import {Header, Icon} from "semantic-ui-react";
import Register from "../../components/register/Register";

function RegisterPage() {
    const authService = new AuthenticationService(useAuth());
    const [errorArea, setErrorArea] = useState(<></>)
    const handleValidSubmit = (registerInfo) => {
        if (registerInfo.password === registerInfo.rePassword) {
            authService.register(registerInfo).then(result => {
                console.log(result)
                if (result?.status !== 200) {
                    setErrorArea((
                        <label style={{marginTop: '16px', color: 'red'}}>Kullanıcı adı veya şifre hatalı</label>
                    ));
                }
            });
        }
        setErrorArea((
            <label style={{marginTop: '16px', color: 'red'}}>Girilen şifreler uyuşmuyor</label>
        ))
    }
    return (
        <div className={'login-container'}>
            <div className={'login-border'}>
                <Header  as='h2'>
                    <Header.Content style={{float:'left'}}>Kullanıcı Girişi</Header.Content>
                </Header>
                <Register onValidSubmit={handleValidSubmit}/>
                {errorArea}
            </div>
        </div>
    )
}

export default RegisterPage;
