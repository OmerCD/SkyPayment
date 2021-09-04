export interface MenuResponseModel {
    id: string;
    name: string;
    items: MenuItemResponse[];
    managementUserId: string;
    restaurantId: string[];
}
export interface MenuItemResponse {
    id: string;
    name: string;
    price: number;
    ingredients: string;
    productContent: ProductContent;
    imageUrl: string;
    isActive: boolean;
}

export enum ProductContent {
    IsVegan = 1,
    IsDiabetic = 2,
    IsGlutenFree = 4,
    IsVegetarian = 8
}
