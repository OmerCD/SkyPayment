import {AxiosInstance} from "axios";
import {useAxiosApi} from "../contexts/api-axios-context";

class MenuService{
    private readonly _axiosApi: AxiosInstance;
    constructor(axiosApi:AxiosInstance) {
        this._axiosApi = axiosApi;
    }
    async getMenuList(restaurantId:string){
        const response = await this._axiosApi.get(`menu/${restaurantId}`);
        return response.data;
    }
    async getMenuContent(restaurantId:string, menuId:string){
        const response = await this._axiosApi.get(`menu/${restaurantId}/${menuId}`);
        return response.data;
    }
}

export const useMenuService = () => {
    const axiosApi = useAxiosApi();
    const menuService = new MenuService(axiosApi);
    return menuService;
}
