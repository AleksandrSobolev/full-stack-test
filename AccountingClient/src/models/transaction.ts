export default class Transaction {
    id = "";
    type = "";
    amount = 0;
    effectiveDate = new Date();

    static parseJson(json: any) {
        if (json === null || json === undefined) return json;

        const { effectiveDate, ...rest } = json;

        return Object.assign(
            new Transaction(),
            {
                effectiveDate: new Date(effectiveDate)
            },
            rest);
    }
}