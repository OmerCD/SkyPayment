import React, {useEffect, useState} from "react";
import {Modal} from "semantic-ui-react";
import {Route, Switch} from "react-router-dom";
import AddRestaurantPage from "./AddRestaurantPage";
import ListRestaurant from "../../components/restaurant/ListRestaurant";
import EditRestaurant from "../../components/restaurant/EditRestaurant";
import RestaurantService from "../../services/RestaurantService";

function RestaurantPage() {
    const [restaurants, setRestaurants] = useState([{
        id: 'testId',
        name: 'TestRestaurant',
        address: 'Bad Address',
        personnelCount: 15
    }]);
    const [restaurantModalState, setRestaurantModalState] = useState({
        open: false,
        header: '',
        selectedRestaurant: {},
        onSubmit: () => {}
    });

    const restaurantService = new RestaurantService();

    useEffect(()=>{
        restaurantService.getAll().then(response => {
            setRestaurants(response);
        })
    },[])

    const onRestaurantAdd = () => {
        setRestaurantModalState({
            header: 'Restoran Ekleme',
            selectedRestaurant: null,
            open: true,
            close: () => {
                setRestaurantModalState({...restaurantModalState, open: false})
            },
            onSubmit: (restaurant) => {
                restaurantService.addRestaurant(restaurant).then(result => {
                    if (result){
                        setRestaurantModalState({...restaurantModalState, open: false});
                    }
                    else{
                        alert("Error")
                    }
                })
            }
        })
    }
    const onRestaurantEdit = (id) => {
        restaurantService.getById(id).then(response => {
            if (response) {
                setRestaurantModalState({
                    header: 'Restoran Düzenleme',
                    selectedRestaurant: response,
                    open: true,
                    close: () => {
                        setRestaurantModalState({...restaurantModalState, open: false})
                    },
                    onSubmit: (restaurant) => {
                        restaurantService.editRestaurant(restaurant).then(updateResult => {
                            setRestaurantModalState({...restaurantModalState, open: false});
                        })
                    }
                })
            }
        })
    }
    const onRestaurantDelete = (id) => {

    }
    return (
        <>
            <Switch>
                <Route path='/restaurants/list'>
                    <ListRestaurant
                        restaurants={restaurants}
                        onAddRestaurant={onRestaurantAdd}
                        onDeleteRestaurant={onRestaurantDelete}
                        onEditRestaurant={onRestaurantEdit}
                    />
                    <RestaurantModal {...restaurantModalState}/>
                </Route>
                <Route path='/restaurants/addRestaurant'>
                    <AddRestaurantPage/>
                </Route>
            </Switch>
        </>
    )
}

const RestaurantModal = ({header, selectedRestaurant, onSubmit, open, close}) => (
    <Modal open={open} onClose={close}>
        <Modal.Header>{header}</Modal.Header>
        <Modal.Content>
            <EditRestaurant restaurant={selectedRestaurant} onSubmit={onSubmit}/>
        </Modal.Content>
    </Modal>
)

export default RestaurantPage;
