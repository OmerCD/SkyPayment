export interface MenuCreateModel {
    name: string;
    items: MenuItemCreateModel[];
    restaurantId: string[];
    managerId: string;
}

export interface MenuItemCreateModel {
    name: string;
    price: number;
    ingredients: string;
    productContent: ProductContent;
    isActive: boolean;
}
export enum ProductContent {
    IsVegan = 1,
    IsDiabetic = 2,
    IsGlutenFree = 4,
    IsVegetarian = 8
}
