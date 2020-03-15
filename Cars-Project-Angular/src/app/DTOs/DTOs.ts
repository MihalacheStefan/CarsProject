export class CarDTO {
    brand: string;
    chassisDescription: string;
    chassisCodeNumber: string;
    engineDescription: string;
    engineCylindersNumber: number;
    usersName: string[];
}

export class ChassisDTO {
    description: string;
    codeNumber: string;
    brands: string[];
}

export class EngineDTO {
    description: string;
    cylindersNumber: number;
    brands: string[];
}

export class UserDTO {
    name: string;
    brands: string[];
}