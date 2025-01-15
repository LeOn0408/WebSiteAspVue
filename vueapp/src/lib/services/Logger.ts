export class Logger {
    logError(message: string, error: any): void {
        console.error(`[${new Date().toISOString()}] ${message}`, error);
    }
}