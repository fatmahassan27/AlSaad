export interface Transaction {
  date: string;
  operationType: string;
  operationValue: number;
  balanceBefore: number;
  balanceAfter: number;
}