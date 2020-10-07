import {BaseRequests} from "../BaseRequests";

export default class RestaurantRequests extends BaseRequests{
    constructor() {
        super();
        this.baseController = 'restaurant';
    }
    getUserRestaurants(){
        return this.axios.get(this.baseController);
    }
    getRestaurant(restaurantId){
        return this.axios.get(this.baseController+'/'+restaurantId);
    }
    addRestaurant(restaurant){
        return this.axios.post(this.baseController, restaurant);
    }
    editRestaurant(restaurant){
        return this.axios.put(this.baseController, restaurant);
    }
    deleteRestaurant(restaurantId){
        return this.axios.delete(this.baseController+'/'+restaurantId);
    }
}
