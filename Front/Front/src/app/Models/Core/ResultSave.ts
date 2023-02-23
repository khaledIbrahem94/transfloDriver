export class ResultSave<TModel = {}> {
  model?: TModel;
  success: boolean = false;
  message: string = '';
}
