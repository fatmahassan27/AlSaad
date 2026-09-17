export interface UnitFactor {
  id: number;
  factorName: string;
  factor: number;
  smallName?: string;
}

export interface UnitTemplate {
  id: number;
  templateName: string;
  isActive: boolean;
  mainUnitName: string;
  unitSmallName?: string;
  unitFactors: UnitFactor[];
}