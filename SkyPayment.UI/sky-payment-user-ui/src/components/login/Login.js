import React, {useState} from "react";
import {Form} from "semantic-ui-react";
import './Login.css';
import {withRouter} from "react-router-dom";

function Login({onValidSubmit, registerClicked}) {
    const handleSubmit = (e) => {
        const formData = new FormData(e.target);
        const submitData = {};
        for (const pair of formData) {
            submitData[pair[0]] = pair[1];
        }
        onValidSubmit(submitData);
    }
        return (
            <Form onSubmit={handleSubmit} className='login-form'>
                <Form.Field>
                    <input placeholder='Kullanıcı Adı' name='userName'/>
                </Form.Field>
                <Form.Field>
                    <input type='password' placeholder='Şifre' name='password'/>
                </Form.Field>
                <Form.Group inline>
                    <Form.Button basic>
                        Giriş
                    </Form.Button>
                    <Form.Field style={{width: '100%', textAlign: 'right'}}>
                        <label className='register-label' onClick={registerClicked}>Yeni Üyelik</label>
                    </Form.Field>
                </Form.Group>
            </Form>
        )

}

export default withRouter(Login);
