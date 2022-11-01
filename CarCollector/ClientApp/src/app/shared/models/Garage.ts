import { Car } from "./Car";
export interface Garage {
    garageId: number;
    name: string;
    streetaddr: string;
    city: string;
    state: string;
    zipcode: number;
    cars: Car[];
}