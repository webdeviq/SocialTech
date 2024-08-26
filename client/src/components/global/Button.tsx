import React, { ReactNode }  from "react";


import { Button as MaterialUiButton, ButtonProps } from "@mui/material";


type MaterialUiButtonProps = {
    children: ReactNode;
} & ButtonProps;

const Button: React.FC<MaterialUiButtonProps> = (props:MaterialUiButtonProps ) => {
  const {children, ...buttonprops } = props;
  return (
    <MaterialUiButton {...buttonprops}>
      {children}
    </MaterialUiButton>
  );
};

export default Button;
