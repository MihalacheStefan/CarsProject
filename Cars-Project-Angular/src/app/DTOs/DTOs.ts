export class CarDTO {
    Brand: string;
    Chassis: ChassisDTO;
    Engine: EngineDTO;
}

export class ChassisDTO {
    Description: string;
    CodeNumber: string;
    Cars: CarDTO[];
}

export class EngineDTO {
    Description: string;
    CylindersNumber: number;
    Cars: CarDTO[];
}
