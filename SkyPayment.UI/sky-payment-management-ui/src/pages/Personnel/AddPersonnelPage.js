import React from "react";
import {Button, Form} from "semantic-ui-react";
import {useLocation} from 'react-router-dom';
import './AddPersonnelPage.css'

const AddPersonnelComponent = ({restaurants, onCreate}) => {
    const mapped = restaurants.map(restaurant => {
        return {
            key: restaurant.id,
            text: restaurant.name,
            value: restaurant.id
        }
    })
    const submitData = {};
    const onSubmit = (e) => {
        const formData = new FormData(e.target);
        for (const pair of formData) {
            submitData[pair[0]] = pair[1];
        }
        if (onCreate) {
            onCreate(submitData);
        }
    }
    const onDropdownChange = (event,data) => {
        submitData.restaurantId = data.value;
    }
    return (
        <Form inverted onSubmit={onSubmit}>
            <Form.Group widths={"equal"}>
                <Form.Input label='İsim' placeholder='İsim' name='name'/>
                <Form.Input label='Soyisim' placeholder='Soyisim' name='lastName'/>
            </Form.Group>
            <Form.Group widths={"equal"}>
                <Form.Input label='Kullanıcı Adı' placeholder='Kullanıcı Adı' name='userName'/>
                <Form.Input label='E-Posta' placeholder='E-Posta' name='email'/>
            </Form.Group>
            <Form.Input label='Şifre' placeholder='Şifre' name='password'/>
            <Form.Dropdown label='Restoran' placeholder='Restoran Seçimi' selection options={mapped}
                           name='restaurantId' onChange={onDropdownChange} onLabelClick={onDropdownChange} />
            <Button floated={"right"} primary>Ekle</Button>
        </Form>
    )
}

function AddPersonnelPage({onSubmit}) {
    const location = useLocation();
    const {restaurants} = location.state;
    return (
        <>
            <h1 className='personnel-create-header'>Personel Ekleme</h1>
            <div className='personnel-create-container'>
                <AddPersonnelComponent restaurants={restaurants} onCreate={onSubmit}/>
            </div>
        </>
    )
}

export default AddPersonnelPage;