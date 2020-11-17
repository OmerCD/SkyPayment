import React from "react";
import {Form} from "semantic-ui-react";
import './Register.css';

function Register({onValidSubmit}){
    const handleSubmit = (e) => {
        const formData = new FormData(e.target);
        const submitData = {};
        for (const pair of formData){
            submitData[pair[0]] = pair[1];
        }
        onValidSubmit(submitData);
    }
    return(
        <Form onSubmit={handleSubmit} className='register-form'>
            <Form.Field>
                <input placeholder='Kullanıcı Adı' name='userName'/>
            </Form.Field>
            <Form.Field>
                <input type='email' placeholder='E-Posta' name='email'/>
            </Form.Field>
            <Form.Field>
                <input placeholder='Ad' name='firstName'/>
            </Form.Field>
            <Form.Field>
                <input placeholder='Soyad' name='lastName'/>
            </Form.Field>
            <Form.Field>
                <input placeholder='Telefon' name="telephoneNumber"/>
            </Form.Field>
            <Form.Field>
                <input type='password' placeholder='Şifre' name='password'/>
            </Form.Field>
            <Form.Field>
                <input type='password' placeholder='Şifre Tekrar' name='rePassword'/>
            </Form.Field>
            <Form.Button basic>
                Giriş
            </Form.Button>
        </Form>
    )
}

export default Register;
