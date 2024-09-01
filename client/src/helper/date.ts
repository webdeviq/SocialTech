/** Converts a possible string to a date and returns the result. */
export const dateParser = (input: string) => {
    const dateConfiguredObject : Intl.DateTimeFormatOptions= {
        weekday: 'long', year: 'numeric', month: 'long', day: 'numeric',
    };
    return new Date(input).toLocaleDateString('en-US', dateConfiguredObject);
    

};
