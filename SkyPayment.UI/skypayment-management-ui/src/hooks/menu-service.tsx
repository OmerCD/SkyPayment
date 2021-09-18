import {AxiosInstance} from "axios";
import {useAxiosApi} from "../contexts/api-axios-context";
import {MenuResponseModel} from "../api-models/menu/MenuResponseModel";

class MenuService {
    private readonly _baseApi: AxiosInstance;

    constructor(baseApi: AxiosInstance) {
        this._baseApi = baseApi;
    }

    async getMenus():Promise<MenuResponseModel[]> {
        const response = await this._baseApi.get('menu/GetMenus');
        if (response.data){
            return response.data;
        }
        else return [];
    }
    async getMenusWithFilter(pageNumber:number, pageSize:number):Promise<MenuResponseModel[]> {
        const response = await this._baseApi.get('menu/GetMenus');
        return response.data;
    }
}

export const useMenuService = (): MenuService => {
    const api = useAxiosApi().baseApi;
    return new MenuService(api);
}
