import React, {useState} from "react";
import AuthenticationService from "../../services/AuthenticationService";
import {useAuth} from "../../context/AuthContext";
import {Header} from "semantic-ui-react";
import Register from "../../components/register/Register";
import {withRouter} from "react-router-dom";

function RegisterPage({history}) {
    const authService = new AuthenticationService(useAuth());
    const [errorArea, setErrorArea] = useState(<></>)
    const handleValidSubmit = (registerInfo) => {
        if (registerInfo.password === registerInfo.rePassword) {
            authService.register(registerInfo).then(result => {
                if (result?.data.isError === true){
                    setErrorArea((
                        <label style={{marginTop: '16px', color: 'red'}}>{result.data.description}</label>
                    ));
                }
                else if (result?.status !== 201) {
                    setErrorArea((
                        <label style={{marginTop: '16px', color: 'red'}}>Bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.</label>
                    ));
                }
                else{
                    history.push('/');
                }
            });
        }
        else {
            setErrorArea((
                <label style={{marginTop: '16px', color: 'red'}}>Girilen şifreler uyuşmuyor</label>
            ))
        }
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

export default withRouter(RegisterPage);
