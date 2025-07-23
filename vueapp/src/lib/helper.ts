export class Helper {
    static FormatDate(originalDate: any) {
        const date = new Date(originalDate);
        //TODO:локализовать
        const monthNames = [
            'Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь',
            'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'
        ];
        const day = date.getDate();
        const monthIndex = date.getMonth();
        const year = date.getFullYear();

        return `${day} ${monthNames[monthIndex]} ${year}`;
    }

    static async sha256(message: string) {
        const msgBuffer = new TextEncoder().encode(message);

        const hashBuffer = await crypto.subtle.digest('SHA-256', msgBuffer);

        const hashArray = Array.from(new Uint8Array(hashBuffer));

        const hashHex = hashArray.map(b => b.toString(16).padStart(2, '0')).join('');
        return hashHex;
    }
    static getAuthHeader(): string {

        const token: string | null = localStorage.getItem('token');
        return token ? `Bearer ${token}` : '';
    }
}
