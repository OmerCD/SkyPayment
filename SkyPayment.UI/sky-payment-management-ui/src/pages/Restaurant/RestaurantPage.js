import React, {useEffect, useState} from "react";
import {Modal} from "semantic-ui-react";
import {Redirect, Route, Switch,useHistory} from "react-router-dom";
import AddRestaurantPage from "./AddRestaurantPage";
import ListRestaurant from "../../components/restaurant/ListRestaurant";
import EditRestaurant from "../../components/restaurant/EditRestaurant";
import RestaurantService from "../../services/RestaurantService";
import RestaurantDetail from "../../components/restaurant/detail/RestaurantDetail";

function RestaurantPage() {
    const [restaurants, setRestaurants] = useState([]);
    const [restaurantModalState, setRestaurantModalState] = useState({
        open: false,
        header: '',
        selectedRestaurant: {},
        onSubmit: () => {
        }
    });
    const history = useHistory();

    const restaurantService = new RestaurantService();

    useEffect(() => {
        restaurantService.getAll().then(response => {
            setRestaurants(response);
        })
    }, []);

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
                    console.log(result)
                    if (result) {
                        restaurantService.getAll().then(response => {
                            setRestaurants(response);
                            setRestaurantModalState({...restaurantModalState, open: false});
                        })
                    } else {
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
        restaurantService.deleteRestaurant(id).then(success => {
            if (success) {
                restaurantService.getAll().then(response => {
                        setRestaurants(response);
                    }
                )
            }
        })
    }
    const onRestaurantDetailsClicked = (id) => {
        if (id){
            history.push("/restaurants/"+id);
        }
    }
    return (
        <>
            <Switch>
                <Redirect from="/restaurants" to='/restaurants/list'
                    exact
                />
                <Route path='/restaurants/list'>
                    <ListRestaurant
                        restaurants={restaurants}
                        onAddRestaurant={onRestaurantAdd}
                        onDeleteRestaurant={onRestaurantDelete}
                        onEditRestaurant={onRestaurantEdit}
                        onDetailClick={onRestaurantDetailsClicked}
                        detailRedirectTo={'/restaurants/'}
                    />
                    <RestaurantModal {...restaurantModalState}/>
                </Route>
                <Route path='/restaurants/addRestaurant'>
                    <AddRestaurantPage/>
                </Route>
                <Route path='/restaurants/:id' component={RestaurantDetail}/>
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
