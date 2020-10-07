import RestaurantRequests from "./requests/restaurant/RestaurantRequests";

class RestaurantService {
    constructor() {
        this.restaurantRequests = new RestaurantRequests();
    }
    async getAll(){
        const response = await this.restaurantRequests.getUserRestaurants();
        return response.data;
    }
    async getById(restaurantId){
        const response = await this.restaurantRequests.getRestaurant(restaurantId)
        return response.data;
    }
    async addRestaurant(restaurant){
        const response = await this.restaurantRequests.addRestaurant(restaurant);
        return response.status === 201;
    }
    async editRestaurant(restaurant){
        const response = await this.restaurantRequests.editRestaurant(restaurant);
        return response.data;
    }

    async deleteRestaurant(restaurantId){
        const response = await this.restaurantRequests.deleteRestaurant(restaurantId)
        return response.status === 201;
    }
}

export default RestaurantService;
