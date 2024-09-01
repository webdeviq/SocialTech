
export const postAnswerText = (input: number) => { 
    switch (input) {
        case 0:
            return 'No Answers';
        case 1:
            return 'Answer';
        default:
            return 'Answers';
    }

};