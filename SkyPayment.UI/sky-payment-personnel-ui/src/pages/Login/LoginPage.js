import React, {useState} from "react";
import Login from "../../components/login/Login";
import AuthenticationService from "../../services/AuthenticationService";
import {useAuth} from "../../context/AuthContext";
import './Login.css';
import {Header, Icon} from "semantic-ui-react";

function LoginPage() {
    const authService = new AuthenticationService(useAuth());
    const [errorArea, setErrorArea] = useState(<></>)
    const handleValidSubmit = (loginData) => {
        authService.login(loginData.userName, loginData.password).then(result => {
            console.log(result)
            if (result.status !== 200){
                setErrorArea((
                    <label style={{marginTop:'16px', color:'red'}}>Kullanıcı adı veya şifre hatalı</label>
                ));
            }
        });
    }
    return (
        <div className={'login-container'}>
            <div className={'login-border'}>
                <Header  as='h2'>
                    <Header.Content style={{float:'left'}}>Personel Girişi</Header.Content>
                </Header>
                <Login onValidSubmit={handleValidSubmit}/>
                {errorArea}
            </div>
        </div>
    )
}

export default LoginPage;
