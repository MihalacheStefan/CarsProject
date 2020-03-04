export class CarDTO {
    Brand: string;
    Chassis: ChassisDTO;
    Engine: EngineDTO;
}

export class ChassisDTO {
    Description: string;
    CodeNumber: string;
}

export class EngineDTO {
    Decription: string;
    CylindersNr: number;
}
