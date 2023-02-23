export class Filter {
  Id = 0;
  pageIndex: number = 0;
  pageRows: number = 10;
  pageSize: number = 10;
  totalRows: number = 0;
  OrderBy: string = "Id";
  OrderType!: "asc" | "desc";
}
