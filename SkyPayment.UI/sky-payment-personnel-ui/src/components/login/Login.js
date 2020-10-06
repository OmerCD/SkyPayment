import React from "react";
import {Form} from "semantic-ui-react";
import './Login.css';

function Login({onValidSubmit}){
    const handleSubmit = (e) => {
        const formData = new FormData(e.target);
        const submitData = {};
        for (const pair of formData){
            submitData[pair[0]] = pair[1];
        }
        onValidSubmit(submitData);
    }
    return(
        <Form onSubmit={handleSubmit} className='login-form'>
            <Form.Field>
                <input placeholder='Kullanıcı Adı' name='userName'/>
            </Form.Field>
            <Form.Field>
                <input type='password' placeholder='Şifre' name='password'/>
            </Form.Field>
            <Form.Button basic>
                Giriş
            </Form.Button>
        </Form>
    )
}

export default Login;
