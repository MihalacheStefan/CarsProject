export class CarDTO {
    Brand: string;
    ChassisDescription: string;
    ChassisCodeNumber: string;
    EngineDescription: string;
    EngineCylindersNumber: number;
}

export class ChassisDTO {
    Description: string;
    CodeNumber: string;
    Brands: string[];
}

export class EngineDTO {
    Description: string;
    CylindersNumber: number;
    Brands: string[];
}
